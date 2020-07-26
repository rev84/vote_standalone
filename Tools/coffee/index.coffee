$().ready ->
  $('.slider, .point').on 'input', ->
    changePoint $(@).attr('subject_id'), $(@).val()
  $('.vote').on 'click', vote

changePoint = (subjectId, point)->
  $('.point[subject_id="'+subjectId+'"]').val(point)
  $('.slider[subject_id="'+subjectId+'"]').val(point)

vote = ->
  subjectId = $(@).attr('subject_id')
  point = $('.point[subject_id="'+subjectId+'"]').val()
  return window.alert('点数は'+window.POINT_MIN+'～'+window.POINT_MAX+'点で入力してください。') unless window.POINT_MIN <= Number(point) <= POINT_MAX
  comment = $('.comment[subject_id="'+subjectId+'"]').val()
  comment = if comment is '' then null else comment
  return window.alert('コメントは'+window.COMMENT_MIN+'～'+window.COMMENT_MAX+'文字で入力してください。') if comment != null and not (window.COMMENT_MIN <= comment.length <= COMMENT_MAX)

  params = 
    SubjectId: subjectId
    Point: point
    Comment: comment

  Utl.request 'subjects/vote', params, onSuccess, onFailure

onSuccess = ->
  window.alert('投票に成功しました。')

onFailure = ->
  window.alert('投票に失敗しました。')
